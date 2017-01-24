require 'meetup_client'

MeetupClient.configure do |config|
  config.api_key = '1110b4476750362f751e3024402a13'
end

params = { country: 'ca',
	city: 'Montreal',
	topic: 'newtech',
	status: 'upcoming',
    format: 'json' }
meetup_api = MeetupApi.new
events = meetup_api.open_events(params)

output = File.new('meetup.html', 'w')
output.puts('<!DOCTYPE html><html><head></head><body><h1>EVENTS</h1>')
for i in 0..6
	case i
	when 0 
		output.puts('<h2>Sunday</h2>')
	when 1 
		output.puts('<h2>Monday</h2>')
	when 2 
		output.puts('<h2>Tuesday</h2>')
	when 3 
		output.puts('<h2>Wednesday</h2>')
	when 4 
		output.puts('<h2>Thursday</h2>')
	when 5 
		output.puts('<h2>Friday</h2>')
	when 6 
		output.puts('<h2>Saturday</h2>')
	end
	for result in events['results']
		day = Time.at(result['time'] / 1000).wday
		if (day == i)
			output.puts('<div><p>Time: ' + result['time'].to_s + '</p>')
			output.puts('<p>Name: ' + result['name'].to_s + '</p>')
			output.puts('<p>Address: ' + result['name']['address_1'].to_s + '</p>')
			output.puts('<p>Description: ' + result['description'].to_s + '</p>')
			output.puts('</div>')
		end
	end
end
output.puts('</body></html>')
output.close

puts 'meetup.html created'
