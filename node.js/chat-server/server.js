var redisHost = 'krist00fer.redis.cache.windows.net';
var redisPass = 'CMwYYbUF7e2ZyYZcXK0JR65XRrqBpCzbDrNwi1bHH5k=';

var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

var webserverPort = process.env.PORT || 3000;

if (process.argv[2]){
	webserverPort = process.argv[2];
}

var pub = require('socket.io-redis/node_modules/redis')
	.createClient(6379, redisHost, {
		auth_pass: redisPass,
		return_buffers: true
	});

var sub = require('socket.io-redis/node_modules/redis')
	.createClient(6379, redisHost, {
		auth_pass: redisPass,
		return_buffers: true
	});

var redis = require('socket.io-redis');
io.adapter(redis({ pubClient: pub, subClient: sub}));

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

io.on('connection', function(socket){
  socket.on('chat message', function(msg){
    io.emit('chat message', msg);
  });
});

http.listen(webserverPort, function(){
  console.log('listening on *:', webserverPort);
});