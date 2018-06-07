'use strict';

const express = require('express');
const app = express();
const path = require('path');
const config = require(path.join(__dirname, 'config.js'));

var count = 0;

app.use(express.static(path.join(__dirname, 'static')));

app.get("/", (req, res) => {
	 console.log('root');
     res.redirect('http://127.0.0.1:'+config.server.port+'/index.html');
})

app.get("/search", (req, res) => {
     count = count + 1;
	 console.log('count = ' + count);
    //res.status(301).redirect("https://www.google.com")
	if (count < 5) {
      res.redirect('http://127.0.0.1:'+config.server.port+'/result1.html');
	} else {
		res.redirect('http://127.0.0.1:'+config.server.port+'/result2.html');
	}
})

app.listen(config.server.port, config.server.ip, () => {
    console.log('Starting listening on port ' + config.server.port);
});
