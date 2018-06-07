'use strict';

const server = {
    ip: process.argv[2] || process.env.NODE_IP || '127.0.0.1',
    port: process.argv[3] || process.env.NODE_PORT || 80
};

module.exports = {
    server
};
