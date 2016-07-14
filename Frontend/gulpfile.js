var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    htmlreplace = require('gulp-html-replace'),
    minifyHTML = require('gulp-htmlmin'),
    gulp_jspm = require('gulp-jspm'),
    manifest = require('gulp-manifest');

gulp.task('default', ['manifest']);

gulp.task('manifest', ['build'], function () {
    return gulp.src(['build/**/*'], { base: 'build/' })
        .pipe(manifest({
            hash: true,
            network: ['*'],
            filename: 'app.appcache',
            exclude: 'app.appcache'
        }))
        .pipe(gulp.dest('build/'));
});

gulp.task('build', ['index', 'jspm']);

gulp.task('jspm', function () {
    return gulp.src('src/app/app.js')
        .pipe(gulp_jspm({selfExecutingBundle: true}))
        .pipe(uglify())
        .pipe(gulp.dest('build/'));
});

gulp.task('index', function () {
    return gulp.src('src/index.html')
        .pipe(htmlreplace({
            'js': 'app.bundle.js'
        }))
        .pipe(minifyHTML({collapseWhitespace:true, conservativeCollapse:true}))
        .pipe(gulp.dest('build/'));
});