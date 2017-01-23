import re
import requests
home = "http://www.mosigra.ru/"
emails = []
visitedUrls = {}
c = 10 #количество переходов
def find(url):
    global c
    global emails
    global visitedUrls
    if c > 0:
        c = c - 1
        r = requests.get(url)
        visitedUrls[url] = 1
        html = r.text
        emails.extend(re.findall(r"mailto:([a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+)", html))
        validUrls = set(re.findall(r"<a href=[\'\"](" + home + r"[\w./]+)", html))
        for item in validUrls:
            if visitedUrls.get(item) == 1:
                continue
            else:
                find(item)
find(home)
print (set(emails))
