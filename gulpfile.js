var gulp = require("gulp");
var gnf = require("gulp-npm-files");
var inject = require("gulp-inject");
var fs = require('fs');

gulp.task("copynpm", function(done) {
    gulp.src(gnf(), {base:"./"}).pipe(gulp.dest("./wwwroot"));
    done();
});

gulp.task('inject', function () {
    var js_files = JSON.parse(fs.readFileSync("./package.json")).js_files;

    var css_files = JSON.parse(fs.readFileSync("./package.json")).css_files;

    var files = js_files.concat(css_files);

    var target = gulp.src('./Views/shared/_Layout.cshtml');

    var sources = gulp.src(files, {read: false});
   
    return target.pipe(inject(sources,{ignorePath:"wwwroot"}))
      .pipe(gulp.dest('./Views/shared'));
});
