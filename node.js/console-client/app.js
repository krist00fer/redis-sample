var redis = require("redis"),
	client = redis.createClient(6379, 'krist00fer.redis.cache.windows.net', { 
		auth_pass: 'CMwYYbUF7e2ZyYZcXK0JR65XRrqBpCzbDrNwi1bHH5k='
	});

client.on("error", function (err) {
	console.log("Error:", err);
});

client.set("barcode", "640509 - 040147", redis.print);
