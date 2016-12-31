var request = require('request');
var home = 'http://www.mosigra.ru';
var emails = {};
var dict = {};
var counter = 10;
var regEmail = new RegExp('mailto:' + '[\\w.-]+@[\\w.-]+\\.\\w+', 'g');
var regUrl = new RegExp('<a href=[\'\"]' + home + '[:/.A-z?<_&\s=>0-9;-]+[\'\"]', 'g');

findEmails(home);

function findEmails(url) {
	counter--;
	if (counter > 0) {
		request(url, function (error, response, body) {
			dict[url] = true;
			var rawEmails = body.match(regEmail).slice();
			var rawValidEmails = [];
			for (var i = 0; i < rawEmails.length; i++) {
				rawValidEmails[i] = rawEmails[i].slice(7);
			}
			for (var i = 0; i < rawEmails.length; i++) {
				emails[rawValidEmails[i]] = true;
			}
			var urls = body.match(regUrl).slice();
			var validUrls = [];
			for (var i = 0; i < urls.length; i++) {
				validUrls[i] = urls[i].slice(9, -1);
			}
			for (var i = 0; i < validUrls.length; i++) {
				if (dict[validUrls[i]] == true) {
					continue;
				} else {
					findEmails(validUrls[i]);
				} 
			}
		});
	} else {
		if (counter == 0) {
			console.log(Object.keys(emails));
		}
	}
}