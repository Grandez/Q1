#load.ggplot2 = suppressPackageStartupMessages(require(ggplot2))
library(ggplot2)
#' calcLM
#' 
#' @description
#' Obtiene la recta de regresion de los datos pasados
#'
#' @rdname Q1 - calcLM
#' @format NULL
#' @param xAxis Vector numerico en secuencia (1, 2, ...)
#' @param yAxis Vector numerico de las cotizaciones
#' @return slope y R2
#' @usage NULL
# @importFrom dplyr filter

#' @export
#' @author Javier Gonzalez?browse
#

plotSpline <- function(yValues, numValues = 0, headers = 1) {
   df = makeDFXY(yValues, numValues, headers)
   BERT.graphics.device(cell=F);
   #BERT.graphics.device(name="spline", cell = T)
   print(df)
   plot = plotBase(df)
   ggplot(df) + theme_bw() + geom_line(aes(x=X, y=Y, colour="red")) 
   # plot(df)
   #p
   #dev.off();
   T
}

graph.histogram <- function(data, main="Histogram", xlabel="Data"){
  
  # passing cell=T means "use the cell address as a unique
  # identifier". otherwise, use the name parameter to identify 
  # the target shape.
  
  BERT.graphics.device(cell=T);

  # scrub the data (slightly) then generate a histogram
  
  x <- unlist( as.numeric( data ));
  df2 = data.frame(X=x)
  
  #ggplot(df2, aes(df2$X)) + geom_histogram()
  hist( x, xlab=xlabel, main=main, col="green", breaks=13, font.main=1);
  
  # we're done with the graphics device; we can shut it off.
  # this isn't strictly necessary, but there's a limit of 63
  # active devices so it's a good idea.
  
  dev.off();
  
  # returning TRUE indicates everything succeeded.  
  
  T
}

prueba <- function() {
    library(ggplot2)
    p1 = qplot(1:10,rnorm(10))
    p2 = qplot(1:10,rnorm(10))
    library(gridExtra)
    grid.arrange(p1, p2, ncol=2, top = "Main title")
}
plotS <- function() {
   print("Entra en la funcion 2")
   y = vector()
   df = makeDF(y, length(y), F)
   print("Hace DF")
   df2 = as.data.frame(spline(x = df$x, y = df$y), n = log10(nrow(df)))      
   print("Cread df 2")
   #BERT.graphics.device(cell=T);
   #BERT.graphics.device(name = "PRUEBA", bgcolor = "white",  width = 400, height = 400, pointsize = 14,  scale = Sys.getenv("BERTGraphicsScale"), cell = F)
   
   BERT.graphics.device(name = "PRUEBA", cell = F)
   plot = plotBase(df2)
   print("Prepara plot")
   pSpline = plot + geom_line(aes(x=x, y=y, colour="blue")) 
   pSpline
   dev.off();
   #T
}

vector <- function() {
   x = c(7916.88,8338.35,8300.86,8269.81,9194.85,9205.12,9578.63,8866,9337.55,
9395.01,
9965.57,
10779.9,
11573.3,
11512.6,
11489.7,
11086.4,
10951,
10397.9,
10725.6,
10366.7,
9664.73,
9813.07,
10301.1,
10005,
10690.4,
11403.7,
11225.3,
10551.8,
11112.7,
10233.9
   )
}

v2 <- function() {
  list(-0.364028445,1.539771579,0.851663727,0.747172488,-0.717008651,-1.929517106,-0.742460302,1.322262281,
0.562216128,2.334947065,0.34522176,-0.750718447,-1.198857955,0.744474181,-1.083791985,-1.051165873,
0.501552578,0.016920007,0.6279922,0.809433014,1.541226761,0.097636418,2.248634061,0.099306756,
0.916118176,1.103401557,1.835193819,-0.577427045,1.220730304,-1.288260202,0.178333005,-0.400340633,
0.664366013,-1.832409467,0.478169231,0.654344029,-1.647156344,0.469116186,-0.963545533,-0.248875049,
-0.841418265,0.912623197,-0.711880096,1.549898975,1.779385338,0.681743191,0.526181206,2.641010512,
1.269612344,-1.954044626,1.447682389,-0.397175307,0.53824364,-0.849546686,0.610797378,-0.824497975,
0.218793748,0.781664688,0.64850755,1.574906339,-1.402707726,-0.181638536,0.115383625,-0.10440312,
0.321893774,-0.045568939,3.021245836,-0.761233953,1.731168916,0.403523386,1.708030848,-0.881768799,
1.340503086,0.031650483,-1.524180261,0.700955587,-1.357586045,0.758067473,-1.305490869,-0.538679904,
2.223353852,-1.239436244,1.598709295,-2.464499493,0.409444458,-1.672399098,0.14452729,-0.629263425,
-0.535479027,-0.613737129,-1.461188667,-0.509104931,0.116094404,0.275050021,0.665410408,0.750984213,
1.200728491,0.15288346,0.313448179,0.514499916,-0.261464198,-0.756953083,0.526003243,-0.270010956,
-0.806886529,-2.512304889,-1.272094334,-1.623983921,-0.798126791,1.337472583,-0.835251667,-0.07698155,
-0.156563299,-0.797601022,0.632937886,-0.559608004,-0.292640278,-0.058520924,-0.024975355,0.426964639
  )
}