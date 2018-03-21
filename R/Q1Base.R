load.ggplot2 = suppressPackageStartupMessages(require(ggplot2))

#' makeDF
#' @description
#' Crea un dataframe a partir del rango pasado y el numero de registros
#' Asume que el eje X sera una secuencia empezando en 1
#' @param yAxis Matriz de nRow x 1
#' 
makeDFXY <- function(yAxis, nRows = 0, headers = 0) {
  if (nRows <= headers) return data.frame()
  
  data <- if (nRows > headers) 
               yAxis[seq(headers + 1, nRows),]
           else
              if (headers > 0)
                 yAxis[-seq(1,headers),]
              else
                 yAxis

   if (is.null(ncol(data))) {
     df = as.data.frame(unlist(data))
   }
   else {
     df = as.data.frame(lapply(split(data, col(data)), unlist))
   }

   rx = if (nRows > 0) 
           seq(nRows - headers, 1, -1)
        else
           seq(nrow(df), 1, -1)

  df2 = as.data.frame(cbind(df, rx))
  colnames(df2) = c("Y", "X")
  df2[order(df2$X),]
}


plotBase <- function(df) {
   g = ggplot(df) + 
       theme_bw() + 
       theme(legend.position = "none") +
       labs(x="Tiempo", y="Cotizacion")
   g
}

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
#' @author Javier Gonzalez
#

calcLM <- function(xAxis, yAxis) {
    # Crear el data frame
    df = data.frame(x=xAxis, y=yAxis)
    
    # Unbias (slope es el mismo)
    xm = mean(df$x)
    ym = mean(df$y)
    df = data.frame(x=df$x - xm - 1, y=df$y - ym)
    
    # Normalize
    df2 = data.frame(x=(df$x - mean(df$x)) / sd(df$x), 
                     y=(df$y - mean(df$y)) / sd(df$y))
                     
    # Regresion linear
    lm1 = lm(y ~ x, df2)
    
    
    media = apply(df10, 2, mean)
    desv = apply(df10, 2, sd)
    mat = mapply(rep, media, 10)
    mdesv = mapply(rep, desv, 10)
    dx = df10 - mat
    dx = dx / mdesv
    
    
    # Devuelve el slope y R2
    c(lm1$coefficients, summary(lm1)$r.squared)
}

graph.histogram <- function(data, main="Histogram", xlabel="Data"){
  
  # passing cell=T means "use the cell address as a unique
  # identifier". otherwise, use the name parameter to identify 
  # the target shape.
  
  BERT.graphics.device(cell=T);

  # scrub the data (slightly) then generate a histogram
  
  x <- unlist( as.numeric( data ));
  hist( x, xlab=xlabel, main=main, col="pink", breaks=13, font.main=1);
  
  # we're done with the graphics device; we can shut it off.
  # this isn't strictly necessary, but there's a limit of 63
  # active devices so it's a good idea.
  
  dev.off();
  
  # returning TRUE indicates everything succeeded.  
  
  T
}