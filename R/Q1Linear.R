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