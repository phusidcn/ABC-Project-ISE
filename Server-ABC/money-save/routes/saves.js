var express = require('express');
var router = express.Router();

var saves = require('../models/saves');

router.get('/', function(req, res) {
  res.render('saves', {
    title: 'Saves',
    saves: saves,
  })
})
module.exports = router;