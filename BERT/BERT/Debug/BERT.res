        ��  ��                  �!      ��
 ��f     0 	        
with( BERT, {

#========================================================
# constants
#========================================================

.EXCEL <- 1;

.ADD_USER_BUTTON <- 100;
.CLEAR_USER_BUTTONS <- 101;

.HISTORY <- 200;
.REMAP_FUNCTIONS <- 300;

.WATCHFILES <- 1020;
.CLEAR <- 1021;
.RELOAD <- 1022;
.CLOSECONSOLE <- 1023;

.CALLBACK <- "BERT_Callback";

#========================================================
# remove "CRANextra" repo
#========================================================
suppressMessages({
	options(repos=getOption("repos")[names(getOption("repos")) != 'CRANextra']);
});

#========================================================
# functions - for general use
#========================================================

#--------------------------------------------------------
# clear buffer.  if you want, you can map this to a 
# 'clear()' function.
#--------------------------------------------------------
ClearBuffer <- function(){ invisible(.Call(.CALLBACK, .CLEAR, 0, PACKAGE=.MODULE )); };

#--------------------------------------------------------
# close the console
#--------------------------------------------------------
CloseConsole <- function(){ invisible(.Call(.CALLBACK, .CLOSECONSOLE, 0, PACKAGE=.MODULE )); };

#--------------------------------------------------------
# reload startup files
#--------------------------------------------------------
ReloadStartup <- function(){ .Call(.CALLBACK, .RELOAD, 0, PACKAGE=.MODULE ); };

#--------------------------------------------------------
# reload functions into excel.  this assumes that the 
# functions have already been sourced() into R.
#--------------------------------------------------------
RemapFunctions <- function(){ .Call( .CALLBACK, .REMAP_FUNCTIONS, 0, PACKAGE=.MODULE ); };

#========================================================
# explicit function registration
#========================================================

.function.map <- new.env();

#--------------------------------------------------------
# map all functions in an environment.  the ... arguments
# are passed to ls(), so use pattern='X' to subset 
# functions in the environment. 
#--------------------------------------------------------
UseEnvironment <- function(env, prefix, category, ...){
	count <- 0;
	if( missing( prefix )){ prefix = ""; }
	else { prefix = paste0( prefix, "." ); }
	if( missing( category )){ category = ""; }
	if(is.character(env)){ env = as.environment(env); }
	lapply( ls( env, ... ), function( name ){
		if( is.function( get( name, envir=env ))){
			fname <- paste0( prefix, name );
			assign( fname, list( name=fname, expr=name, envir=env, category=category ), envir=.function.map );
			count <<- count + 1;
		}
	});
	if( count > 0 ){ .Call( .CALLBACK, .REMAP_FUNCTIONS, 0, PACKAGE=.MODULE ); }
	return( count > 0 );
}

#--------------------------------------------------------
# this is an alias for UseEnvironment that prepends the
# package: for convenience.
#--------------------------------------------------------
UsePackage <- function( pkg, prefix, category, ... ){
	require( pkg, character.only=T );
	UseEnvironment( paste0( "package:", pkg ), prefix, category, ... );
}

#--------------------------------------------------------
# remove mapped environment/package functions
#--------------------------------------------------------
ClearMappedFunctions <- function(){
	rm( list=ls(.function.map), envir=.function.map );
	.Call( .CALLBACK, .REMAP_FUNCTIONS, 0, PACKAGE=.MODULE );
}

#========================================================
# API for user buttons
#========================================================

.UserButtonCallbacks <- list();
.UserButtonCallback <- function(index){
	return(.UserButtonCallbacks[[index+1]]$FUN());
}

#--------------------------------------------------------
# add a user button.  these are added to the ribbon,
# there's a max of 6.  callback is an R function.
#--------------------------------------------------------
AddUserButton <- function( label, FUN, imageMso = NULL ){

	ubc <- structure( list(), class = "UserButtonCallback" );
	ubc$label <- label;
	ubc$FUN <- FUN;
	ubc$imageMso <- imageMso;

	.Call(.CALLBACK, .ADD_USER_BUTTON, c( label, "BERT$.UserButtonCallback", imageMso ), 0, PACKAGE=.MODULE);

	len <- length( .UserButtonCallbacks );
	.UserButtonCallbacks[[len+1]] <<- ubc;
}

#--------------------------------------------------------
# list user buttons
#--------------------------------------------------------
ListUserButtons <- function(){
	print( .UserButtonCallbacks );
}

#--------------------------------------------------------
# remove user buttons
#--------------------------------------------------------
ClearUserButtons <- function(){
	.UserButtonCallbacks <<- list();
	.Call(.CALLBACK, .CLEAR_USER_BUTTONS, 0, 0, PACKAGE=.MODULE);
}

#========================================================
# API for the file watch utility
#========================================================

.WatchedFiles <- new.env();

.RestartWatch <- function(){

	# we watch the functions dir by default.  you can overload behavior by
	# watching the folder with a specific function.

	path = gsub( "\\\\+$", "", gsub( "/", "\\\\", tolower(normalizePath(BERT$STARTUP_FOLDER))));
	if( !exists( path, envir=.WatchedFiles )) .WatchedFiles[[path]] = NULL;

	rslt <- .Call( BERT$.CALLBACK, BERT$.WATCHFILES, ls(.WatchedFiles), 0, PACKAGE=BERT$.MODULE );
	if( !rslt ){
		cat( "File watch failed.  Make sure the files you are watching exist and are readable.\n");
	}
}
.RestartWatch();

.ExecWatchCallback <- function( path ){

	path = gsub( "\\\\+$", "", gsub( "/", "\\\\", tolower(normalizePath(path)) ))

	# it's possible that both the directory and the specific file are 
	# being watched.  we want to support that pattern.  check the directory
	# first and execute (call with the path to the changed file)

	dir = gsub( "\\\\+$", "", gsub( "/", "\\\\", dirname(path)))
	if( exists( dir, envir=.WatchedFiles )){
		FUN = .WatchedFiles[[dir]];
		if( is.null(FUN)){
			FUN = function(a){
				if( grepl( "\\.(?:rscript|r|rsrc)$", a, ignore.case=T )){
					source(a, chdir=T);
					BERT$RemapFunctions();
				}
				else {
					cat("skipping file (invalid extension)\n");
				}
			}
		}
		cat(paste("Executing code on file change:", path, "\n" ));
		do.call(FUN, list(path));
	}

	# now look for the specific file and execute that function.
	# for backwards-compatibility purposes there are no arguments.

	if( exists( path, envir=.WatchedFiles )){
		FUN = .WatchedFiles[[path]];
		if( is.null(FUN)){
			FUN = function(a=path){
				if( grepl( "\\.(?:rscript|r|rsrc)$", a, ignore.case=T )){
					source(a, chdir=T);
					BERT$RemapFunctions();
				}
				else {
					cat("skipping file (invalid extension)\n");
				}
			}
		}
		cat(paste("Executing code on file change:", path, "\n" ));
		do.call(FUN, list());
	}

}

#--------------------------------------------------------
# watch file, execute code on change
#--------------------------------------------------------
WatchFile <- function( path, FUN=NULL, apply.now=F ){
	path = gsub( "\\\\+$", "", gsub( "/", "\\\\", tolower(normalizePath(path)) ));
	.WatchedFiles[[path]] = FUN;
	.RestartWatch();
} 

#--------------------------------------------------------
# stop watching file (by path)
#--------------------------------------------------------
UnwatchFile <- function( path ){
	path = gsub( "\\\\+$", "", gsub( "/", "\\\\", tolower(normalizePath(path)) ))
	rm( list=path, envir=.WatchedFiles );
	.RestartWatch();
}

#--------------------------------------------------------
# remove all watches (except default)
#--------------------------------------------------------
ClearWatches <- function(){
	rm( list=ls(.WatchedFiles), envir=.WatchedFiles );
	.RestartWatch();
}

#--------------------------------------------------------
# list watches - useful if something unexpected is happening
#--------------------------------------------------------
ListWatches <- function(){
	ls(.WatchedFiles);
}

#--------------------------------------------------------
# Excel callback function. Be careful with this unless 
# you know what you are doing.
#--------------------------------------------------------
.Excel<- function( command, arguments = list() ){ .Call(.CALLBACK, .EXCEL, command, arguments, PACKAGE=.MODULE ); };

}); # end with(BERT)

   �      �� ��h     0	         ��        � Ȇ     � �     O p t i o n s    � M S   S h e l l   D l g              Pf � 2     ��� O K               P� � 2     ��� C a n c e l             � �P  �  �  ���             � �P 0 �  �  ���             � �P N �  �  ���             � �P l �  �  ���               P & 9  ������� R   H o m e   D i r e c t o r y               P  6  ������� R   U s e r   D i r e c t o r y               P D /  ������� S t a r t u p   F o l d e r               P b �  ������� E n v i r o n m e n t   ( B l a n k   f o r   G l o b a l   E n v i r o n m e n t )              P � k 
   ���   S a v e   R   E n v i r o n m e n t   o n   E x i t       &      �� ��     0	         ��        � Ȁ     � p     A b o u t    � M S   S h e l l   D l g              Py [ L     ��� O K               P  �  �  ��� ( A b o u t   B E R T )               P  �  �  ��� ( B e r t   L i n k )                 P ; �  �  ��� ( R   L i n k )               P) [ L     ��� C h e c k   f o r   U p d a t e s                @ * �    ��� C h e c k i n g   f o r   u p d a t e s . . .                 P * �  �  ��� ( A b o u t   R )                @ : �    ��� C h e c k i n g   f o r   u p d a t e s . . .       �      �� ��m     0	         ��        � Ȁ     � �     C o n s o l e   O p t i o n s    � M S   S h e l l   D l g             !P 8 �  �  ���              !P� 8 .  �  ���              �P O   �  ���                  �P d   �  ���                  �P y   �  ���                  PP � 2     ��� O K               P� � 2     ��� C a n c e l               X� � 2     ��� A p p l y                 P* S 9  ������� B a c k g r o u n d   C o l o r               P , &  ������� F o n t   F a m i l y                 P* h 3  ������� U s e r   T e x t   C o l o r                 P* } @  ������� M e s s a g e   T e x t   C o l o r               P� ,   ������� F o n t   S i z e                 �P  �  �  ��� S t a t i c             � �Pq � 3  �  ���               P � Z  ������� C o n s o l e   W i d t h   ( C h a r a c t e r s )              P� � 0 
 �  ��� A u t o m a t i c                P � � 
   ��� S a v e   c o n s o l e   h i s t o r y   b e t w e e n   s e s s i o n s       "      �� ��l     0	            � & M e n u     F�& H o m e   D i r e c t o r y     D�& R e l o a d   S t a r t u p   F i l e     E�& I n s t a l l   P a c k a g e s     C�C l e a r   & B u f f e r           O�A l w a y s   O n   & T o p     M�C o n s o l e   & O p t i o n s         � A�& C l o s e   C o n s o l e     Q  $   P N G   ��q     0 	        �PNG

   IHDR   @   @   �iq�   tEXtSoftware Adobe ImageReadyq�e<  "iTXtXML:com.adobe.xmp     <?xpacket begin="﻿" id="W5M0MpCehiHzreSzNTczkc9d"?> <x:xmpmeta xmlns:x="adobe:ns:meta/" x:xmptk="Adobe XMP Core 5.0-c061 64.140949, 2010/12/07-10:57:01        "> <rdf:RDF xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#"> <rdf:Description rdf:about="" xmlns:xmp="http://ns.adobe.com/xap/1.0/" xmlns:xmpMM="http://ns.adobe.com/xap/1.0/mm/" xmlns:stRef="http://ns.adobe.com/xap/1.0/sType/ResourceRef#" xmp:CreatorTool="Adobe Photoshop CS5.1 Windows" xmpMM:InstanceID="xmp.iid:5F2A05B8FF0811E4B89AFB6FA17B38FA" xmpMM:DocumentID="xmp.did:5F2A05B9FF0811E4B89AFB6FA17B38FA"> <xmpMM:DerivedFrom stRef:instanceID="xmp.iid:5F2A05B6FF0811E4B89AFB6FA17B38FA" stRef:documentID="xmp.did:5F2A05B7FF0811E4B89AFB6FA17B38FA"/> </rdf:Description> </rdf:RDF> </x:xmpmeta> <?xpacket end="r"?>�!5  �IDATx��[K��@Ŏ��b8}��O�p�4n\�z���3K7�	dN �`���'6�v2#�"r���B�Je��UT���˲�G��rg�\  �� ` �tt�e2}�ױt/���QN��1��n ��cP&B0���Bӌ�ŷ  J�3�dʮ]8l�;�0�J @y��?9�P�e�쒕���� N;��A_�m���z��me��`�ЌG���-���t騴�#����/��B�B���!}JVq�Y��8�Y�  {�C�lbĈn�}?�ZE���Ӻ0A"2*���g�G>�����6�w�J������]Ǔ�lq�u�A�M��=FQ=�)y�dD�_c<�ڳqL����7��4�A�e����A����g�˴�i� `���@�F�ĝ� 0Х�ԋϔ���Q��lw�=LƁ��n �"��4�
��������99V����K��"�-�q�bc ���D��|�Ll��<?NΘy���Spn����e����0�U��B!_a��e�� ��;�~�H��Q�]V!y��TqJ(�(��I�� l�̓O(X!\�2�uCM&��m���e �i�V��>�����ʃdaxo@������A��A�S�E���[d�NW d��%{� ��T�xU�V �:������
 ����`�.G}Y���F�2�$m�
"�+�Q� ���������ƈ���='`+XcݴX���@�/�&&bД�#F��':6H�,O��X�W����~=F�W��3 Q�j�
�`S��]�2�"[ZL�;��@��h+��[��N�5��� <�VE ��oq ����Eq��Z��=HJ9�;����6���E?u)m��H ���JYE��R �un�Ծ B��Wu���������Z(����?8љ�K0��   ����O� ��~�{�x    IEND�B`�      @   A F X _ D I A L O G _ L A Y O U T   ��     0 	               @   A F X _ D I A L O G _ L A Y O U T   ��h     0 	               @   A F X _ D I A L O G _ L A Y O U T   ��m     0 	            