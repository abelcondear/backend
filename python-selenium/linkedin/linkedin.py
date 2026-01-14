from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.service import Service
import time
import json

class EasyApplyLinkedin:
    def __init__(self, data):
        self.email = data['email']
        self.password = data['password']
        self.keywords = data['keywords']
        self.location = data['location']

        s = Service(data['driver_path'])
        self.driver = webdriver.Chrome(service=s)

    def login_linkedin(self):
        self.driver.get("https://www.linkedin.com/login")

        login_email = self.driver.find_element(By.NAME, 'session_key')
        login_email.clear()
        login_email.send_keys(self.email)

        login_pass = self.driver.find_element(By.NAME, 'session_password')
        login_pass.clear()
        login_pass.send_keys(self.password)
        login_pass.send_keys(Keys.RETURN)
    
    def job_search(self):
        jobs_link = self.driver.find_element(By.XPATH,'//span[@title="Jobs"]')        
        jobs_link.click()

        time.sleep(10)

        search_keywords = None
        search_location = None

        for input_element in self.driver.find_elements(By.XPATH,'//input'):
            id = input_element.get_property('id')
            
            if id.find('search-box-keyword') != -1:
                search_keywords = input_element

            if id.find("search-box-location") != -1:
                search_location = input_element

            if search_keywords and search_location:             
                break

        search_keywords.clear()
        search_keywords.send_keys(self.keywords)
        time.sleep(1)

        search_location.clear()
        search_location.send_keys(self.location)
        search_location.send_keys(Keys.RETURN)
        time.sleep(1)


    def filter(self):
        all_filters_button = None
        easy_apply_button = None

        for button_element in self.driver.find_elements(By.XPATH,'//button'):
            value = button_element.text
            
            if value.strip() == 'Easy Apply':
                all_filters_button = button_element

            if value.strip() == 'All filters':
                easy_apply_button = button_element

            if all_filters_button and easy_apply_button:             
                break

        all_filters_button.click()
        time.sleep(1)
        
        easy_apply_button.click()
        time.sleep(1)

    def close_session(self):
        print('End of the session.')
        self.driver.close()

    def apply(self):
        self.driver.maximize_window()
        
        self.login_linkedin()
        time.sleep(5)
        
        self.job_search()
        time.sleep(5)
        
        self.filter()
        time.sleep(5)
        
        self.close_session()


if __name__ == '__main__':
    with open('config.json') as config_file:
        data = json.load(config_file)

    bot = EasyApplyLinkedin(data)
    bot.apply()