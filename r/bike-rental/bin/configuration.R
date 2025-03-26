library(hash)


set_all_config <- function() {
  bike <- hash()
  hhmm <- hash()
  label <- hash()

  arr_weather <- list("hot","cold","rainy")
  arr_season <- list("summer", "winter", "autumn", "spring")
  
  bike[["prefix_len"]] <- 4
  bike[["suffix_len"]] <- 4
  
  hhmm[["hour_len"]] <- 2
  hhmm[["minute_len"]] <- 2
  
  label[["first"]] <- "09:00 AM-10:00 AM"
  label[["second"]] <- "10:00 AM-12:00 PM"
  label[["third"]] <- "12:00 PM-02:00 PM"
  label[["fourth"]] <- "02:00 PM-04:00 PM"
  label[["fifth"]] <- "04:00 PM-06:00 PM"
  label[["sixth"]] <- "06:00 PM-07:00 PM"
  
  label[["morning"]] <- "morning"
  label[["midday"]] <- "midday"
  label[["afternoon"]] <- "afternoon"
  label[["evening"]] <- "evening"
}

set_all_config()
