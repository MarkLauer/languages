import re
_input = open('access.log', 'r')
ip_list = re.findall(r'(?:25[0-5]|2[0-4]\d|[0-1]?\d{1,2})(?:\.(?:25[0-5]|2[0-4]\d|[0-1]?\d{1,2})){3}\b', _input.read())
_input.close()
dic = {}
for item in ip_list:
    if item in dic:
        dic[item] += 1
    else:
        dic[item] = 1
_output = open('output.txt', 'w')
keys = dic.keys()
result = re.findall(r'[1-2]?[0-9]?[0-9]\.[1-2]?[0-9]?[0-9]\.[1-2]?[0-9]?[0-9]\.', str(keys)) 
for item1 in result:
    for item2 in keys:
        if item2.startswith(item1):
            _output.write(item2)
            _output.write(' ')
            _output.write(str(dic[item2]))
            _output.write('\n')
    _output.write('\n')
_output.close()
