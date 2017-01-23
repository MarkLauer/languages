if File.exist?("access.log")
	input = File.new("access.log", "r")
	regexp_ip = /(?:25[0-5]|2[0-4]\d|[0-1]?\d{1,2})(?:\.(?:25[0-5]|2[0-4]\d|[0-1]?\d{1,2})){3}\b/
	regexp_sub = /[1-2]?[0-9]?[0-9]\.[1-2]?[0-9]?[0-9]\.[1-2]?[0-9]?[0-9]\./
	ip_array = input.read.scan(regexp_ip)
	input.close
	ip_hash = Hash.new(0)
	for ip in ip_array
		ip_hash[ip] += 1
	end
	output = File.new("output.txt", "w")
	sub_array = ip_array.uniq.to_s.scan(regexp_sub)
	for sub in sub_array
		for ip in ip_array.uniq
			if (ip.start_with?(sub))
				output.print(ip + " " + ip_hash[ip].to_s + "\n")
			end
		end
		output.print("\n")
	end
	output.close
	print "output.txt created"
else
	print "access.log not found"
end
