from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException, StaleElementReferenceException
from selenium.webdriver.chrome.service import Service

import time
import os

driver = None

def startSession():
    global driver

    s = Service(".\\chromedriver-win64\\chromedriver.exe")
    driver = webdriver.Chrome(service=s)

    path = os.getcwd().replace("\\","/")
    url = f"file:///{path}/form.html"

    driver.get(url)

def endSession():
    global driver

    time.sleep(11.5)
    driver.close()

def xfind( rule, plural=False ):        
    global driver

    element = None

    try:
        if plural:
            element = driver.find_elements(By.CLASS_NAME, rule)
        else:
            element = driver.find_element(By.CLASS_NAME, rule)

    except NoSuchElementException:
        pass
    except StaleElementReferenceException:
        pass
    
    if not element:
        time.sleep(1.5)        
        element = find(rule, plural)

    return element

def find( xpath, plural=False ):        
    global driver

    element = None

    try:
        if plural:
            element = driver.find_elements(By.XPATH, xpath)
        else:
            element = driver.find_element(By.XPATH, xpath)

    except NoSuchElementException:
        pass
    except StaleElementReferenceException:
        pass
    
    if not element:
        time.sleep(1.5)        
        element = find(xpath, plural)

    return element


if __name__ == '__main__':
    startSession() 

    e = find('//input', True)

    for input in e:
        ( name, id ) = [ input.get_property('name'), input.get_property('id') ]

        if id == 'btnSave':
            input.click()
            time.sleep(5)
            
        if id == 'optTeamLead':
            input.click()
            time.sleep(5)

        if name == 'editFullName':
            input.clear()
            input.send_keys('John Smith')
            time.sleep(5)

    e = find('//button', True)

    for button in e:
        id = button.get_property('id') 

        if id == 'btnSaveAll':
            if button.text.strip() == 'Save All':
                button.click()
                time.sleep(5)

    e = xfind('divBoxContainer', True)

    for div in e:
        driver.get(div.find_element(By.TAG_NAME, 'a').get_property('href'))
        time.sleep(5)

    endSession()   

