var gulp = require('gulp'),
    concat = require('gulp-concat'),
    streamqueue = require('streamqueue'),
    uglify = require('gulp-uglify'),
    htmlreplace = require('gulp-html-replace'),
    minifyHTML = require('gulp-htmlmin'),
    gulp_jspm = require('gulp-jspm'),
    templateCache = require('gulp-angular-templatecache'),
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

gulp.task('build', ['index', 'jspm', 'templates']);

gulp.task('templates', function() {
    return gulp
        .src(['src/**/*.html', '!src/jspm_packages/**/*.html', '!src/index.html'])
        .pipe(minifyHTML({collapseWhitespace:true, conservativeCollapse:true}))
        .pipe(templateCache('templates.min.js', {root:'', module:'wall-app'}))
        .pipe(uglify())
        .pipe(gulp.dest('build/'));
})

gulp.task('jspm', function () {
    return gulp.src('src/app/app.js')
        .pipe(gulp_jspm({selfExecutingBundle: true}))
        .pipe(uglify())
        .pipe(concat('app.min.js'))
        .pipe(gulp.dest('build/'));
});

gulp.task('index', function () {
    return gulp.src('src/index.html')
        .pipe(htmlreplace({
            'js': ['app.min.js', 'templates.min.js']
        }))
        .pipe(minifyHTML({collapseWhitespace:true, conservativeCollapse:true}))
        .pipe(gulp.dest('build/'));
});