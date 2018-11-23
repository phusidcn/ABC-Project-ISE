var express = require('express');
var router = express.Router();

var Save = require('../models/saves');
 router.get('/', function(req, res) {
   Save.find(function(err, saves) {
     if (err) return console.error(err);
     res.render('saves', {title: 'Saves', saves: saves});
   }); 
 });

module.exports = router;