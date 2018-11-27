var express = require('express');
var router = express.Router();

var Save = require('../models/save');
 router.get('/', function(req, res) {
   Save.find(function(err, save) {
     if (err) return console.error(err);
     res.render('save', {title: 'Saves', save: save});
   }); 
 });

module.exports = router;