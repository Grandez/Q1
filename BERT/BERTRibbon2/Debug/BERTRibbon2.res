        ��  ��                  @      �� ��     0 	        @4   V S _ V E R S I O N _ I N F O     ���               ?                       �   S t r i n g F i l e I n f o   |   0 4 0 9 0 4 B 0   J   C o m p a n y N a m e     T O D O :   < C o m p a n y   n a m e >     Z   F i l e D e s c r i p t i o n     T O D O :   < F i l e   d e s c r i p t i o n >     0   F i l e V e r s i o n     1 . 0 . 0 . 1   � 0  L e g a l C o p y r i g h t   T O D O :   ( c )   < C o m p a n y   n a m e > .     A l l   r i g h t s   r e s e r v e d .   @   I n t e r n a l N a m e   B E R T R i b b o n 2 . d l l   H   O r i g i n a l F i l e n a m e   B E R T R i b b o n 2 . d l l   J   P r o d u c t N a m e     T O D O :   < P r o d u c t   n a m e >     4   P r o d u c t V e r s i o n   1 . 0 . 0 . 1   D    V a r F i l e I n f o     $    T r a n s l a t i o n     	��  0   R E G I S T R Y   ��e       0 	        HKCU
{
	Software
	{
		Classes
		{
			BERTRibbon.Connect.2 = s 'BERT Ribbon Menu Class'
			{
				CLSID = s '{0445D07A-354A-4FD2-9B38-B42221BA53B7}'
			}
			BERTRibbon.Connect = s 'BERT Ribbon Menu Class'
			{
				CLSID = s '{0445D07A-354A-4FD2-9B38-B42221BA53B7}'
				CurVer = s 'BERTRibbon.Connect.2'
			}
			NoRemove CLSID
			{
				ForceRemove '{0445D07A-354A-4FD2-9B38-B42221BA53B7}' = s 'BERT Ribbon Menu Class'
				{
					ProgID = s 'BERTRibbon.Connect.2'
					VersionIndependentProgID = s 'BERTRibbon.Connect'
					ForceRemove 'Programmable'
					InprocServer32 = s '%MODULE%'
					{
						val ThreadingModel = s 'Apartment'
					}
					'TypeLib' = s '{BB49688B-03E5-4703-8175-99CF97125C80}'
				}
			}
		}
		Microsoft
		{
			Office
			{
				Excel
				{
					NoRemove Addins
					{
						ForceRemove BERTRibbon.Connect
						{
							val Description = s 'BERTRibbon BERT Ribbon Menu Class'	
							val FriendlyName = s 'BERT Ribbon Menu'
							val LoadBehavior = d 3
						}
					}
				}
			}
		}
	}
}


  �  $   X M L   ���     0 	        <?xml version="1.0" encoding="utf-8"?>
<customUI xmlns="http://schemas.microsoft.com/office/2006/01/customui" onLoad="RibbonLoaded">

  <!-- add to, don't replace, the whole ribbon -->
  <ribbon startFromScratch="false">
    <tabs>

      <tab idMso="TabAddIns">
        <group id="g1" label="Basic Excel R Toolkit">
          <button id="b1" label="BERT Console" size="large" onAction="ShowConsole" imageMso="CreateStoredProcedure" supertip="Open the BERT console"/>
          <separator id="separator1" />
          <button id="b2" label="BERT Home" onAction="HomeDirectory" imageMso="FileOpen" supertip="Open the BERT home directory"/>
          <button id="b7" label="Startup Folder" onAction="StartupFolder" imageMso="FileOpen" supertip="Open the startup folder"/>
          <button id="b5" label="Configure" onAction="Configuration" imageMso="ComAddInsDialog" supertip="Change configuration settings"/>
          <separator id="separator2" />
          <button id="b6" label="About" onAction="AboutBERT" imageMso="Info" supertip="About BERT and credits"/>
        </group>
        <group id="g2" label="BERT User Functions" getVisible="getUserButtonsVisible">
          <button id="user1" getImage="getUserButtonImage" getLabel="getUserButtonLabel" getVisible="getUserButtonVisible" onAction="userButtonAction" tag="1"/>
          <button id="user2" getImage="getUserButtonImage" getLabel="getUserButtonLabel" getVisible="getUserButtonVisible" onAction="userButtonAction" tag="2"/>
          <button id="user3" getImage="getUserButtonImage" getLabel="getUserButtonLabel" getVisible="getUserButtonVisible" onAction="userButtonAction" tag="3"/>
          <button id="user4" getImage="getUserButtonImage" getLabel="getUserButtonLabel" getVisible="getUserButtonVisible" onAction="userButtonAction" tag="4"/>
          <button id="user5" getImage="getUserButtonImage" getLabel="getUserButtonLabel" getVisible="getUserButtonVisible" onAction="userButtonAction" tag="5"/>
          <button id="user6" getImage="getUserButtonImage" getLabel="getUserButtonLabel" getVisible="getUserButtonVisible" onAction="userButtonAction" tag="6"/>
        </group>
      </tab>

    </tabs>
  </ribbon>
</customUI>
 �  ,   T Y P E L I B   ��     0 	        MSFT      	      A                                   ����       �   ����       H  d   ����   �     ����   �     ����   �     ����   �  �   ����   ,  �   ����        ����     0   ����   <  0   ����   ����    ����   ����    ����   l  T   ����   �  $   ����   ����    ����   ����    ����   %"  �                                     `                         ����                  �����   ��������������������������������������������������������������������x   ����������������    H      `   ����������������0   �hI��G�u�ϗ\���������e�w�|Q���  �w<���������c�w�|Q���  �w<���������d�w�|Q���  �w<���������z�EJ5�O�8�"!�S�    ����0     �      F   ����        �      F   ����      ��������      �   x          - stdole2.tlbWWW������������������������������������������������������������������������������������������������������������������������������������������������������������    ����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������   ���������������������������������������������������������������������������������������������������������������������������������������������������� �<BERTRibbon2LibWW    ����8\�ConnectW BERTRibbon 2.0 Type LibraryWWW BERT RibbonWWW >   Created by MIDL version 8.01.0620 at Tue Jan 19 04:14:07 2038
 ���WW lWW       ����0   D       H   L      6       �� ��     0	                 B E R T R i b b o n 2                         