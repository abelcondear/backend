library(hash)
source("configuration.R")

createModel <- function(name){
  fileConn<-file(name)
  writeLines(c("aaaa","bbbb","cccc","dddd","eeee", "ffff"), fileConn)
  close(fileConn)
}

getRandomN <- function(maximum, minimum){
  return( ceiling(runif(n=1, min=minimum, max=maximum)) )  
}

getCurrentYear <- function(){
  return(format(Sys.Date(), "%Y"))
}

createNumber <- function(len, leading_zero=TRUE) {
  retval <- ""
  if (leading_zero){
    zero <- ""  
    
    for(x in 1:len-1){ 
      zero <- c(zero, "0")  
    }
    
    retval <- paste(c(paste(zero, collapse=""), getRandomN(100, 10)), collapse="")
    retval <- substring(retval, nchar(retval) - (len-1), nchar(retval))
  }
  else {
    num <- ""
    for(x in 1:len){ num <- c(num, getRandomN(9, 1)) }
    retval <- paste(num, collapse="");
  }
  
  return(retval)  
}

createAlpha <- function(len){
  retval <- ""
  for (x in 1:len) {
    chr <- intToUtf8(getRandomN(90, 65))
    retval <- c(retval, chr)
  }
  
  return(paste(retval, collapse=""))
}

createLine <- function(rowid) {
  retval <- "--not implemented yet--"

  id <- rowid
  bike_model<- 0
  quantity <- 0
  hour <- 0
  date <- 0
  from_to <- 0
  shift <- 0 
  weather <- 0
  season <- 0
  
  retval <- c(
    id,
    bike_model,
    quantity, 
    hour, 
    date,
    from_to, 
    shift, 
    weather, 
    season
  );
  
  return(paste(retval,collapse=";"))
}

set_all_config()
createNumber(4, TRUE)
createAlpha(4)
createLine(1)

