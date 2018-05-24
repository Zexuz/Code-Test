var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function (req, res, next) {
    res.render('index', {title: 'Recommended ski length'});
});


router.get('/result', function (req, res, next) {
    res.render('result', {
        title: 'Result',
        age: req.query.age,
        height: req.query.height,
        skiType: req.query.skitype,
        min: req.query.min,
        max: req.query.max,
    });
});

module.exports = router;
