load.ggplot2 = suppressPackageStartupMessages(require(ggplot2))
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
   #BERT.graphics.device(cell=T);
   #BERT.graphics.device(name="spline", cell = T)
   
   plot = plotBase(df)
   plot + geom_line(aes(x=X, y=Y, colour="red")) 
   
   #dev.off();
   T
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
