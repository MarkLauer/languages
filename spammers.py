import re
import requests
home = 'http://www.mosigra.ru/'
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
        emails.extend(re.findall(r'mailto:[\w.-]+@[\w.-]+\.\w+', html))
        validUrls = set(re.findall('<a href=[\'\"]' + home + r'[\w./]+', html))
        for item in validUrls:
            if visitedUrls.get(item[9:]) == 1:
                continue
            else:
                find(item[9:])
find(home)
for i in range(len(emails)):
    emails[i] = emails[i][7:]
print (set(emails))
