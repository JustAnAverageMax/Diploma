import os
import requests
from bs4 import BeautifulSoup

# Имя файла со списком URL-адресов
filename = 'list.txt'

# Папка, в которой будут сохранены картинки
folder_name = 'allImages'

# Создаем папку, если ее нет
if not os.path.exists(folder_name):
    os.makedirs(folder_name)

# Открываем файл и получаем список URL-адресов
with open(filename, 'r') as f:
    url_list = [line.strip() for line in f]

# Проходим по списку URL-адресов
for url in url_list:
    # Получаем содержимое страницы
    print(url)
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'lxml')
    
    # Извлекаем все теги <img> на странице
    img_tags = soup.find_all('img')
    
    # Проходим по списку тегов <img>
    for img in img_tags:
        # Получаем URL-адрес картинки
        img_url = img.attrs.get('src')
        
        # Скачиваем картинку
        if img_url and ('http' in img_url):
            filename = os.path.join(folder_name, img_url.split('/')[-1])
            with open(filename, 'wb') as f:
                f.write(requests.get(img_url).content)
                print('Картинка {} сохранена'.format(filename))
