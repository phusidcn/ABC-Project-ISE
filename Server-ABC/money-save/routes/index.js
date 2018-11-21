var express = require('express');
var router = express.Router();


/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

// /* GET my save page */
// router.get('/:mysave', function(req, res, next) {
//   var title = req.params.mysave;
//   res.render('index', {title: title});
// })

module.exports = router;
