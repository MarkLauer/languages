import re
import requests
home = 'http://www.mail.ru/'
emails = []
_dict = {}
valid_urls = set()
def goin(url, n):
    if n > 0:
        r = requests.get(url)
        _dict[url] = 1
        html = r.text
        emails.extend(re.findall(r'[\w.-]+@[\w.-]+\.\w+', html))
        global valid_urls
        valid_urls = set(re.findall(home + r'[\w./]+', html))
        for item in valid_urls:
            if _dict.get(item) == 1:
                continue
            else:
                goin(item, n - 1)
goin(home, 2)
print (set(emails))