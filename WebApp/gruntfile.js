'use strict';

module.exports = function(grunt) {

    require('load-grunt-tasks')(grunt);

    require('time-grunt')(grunt);

    grunt.initConfig({

        wiredep: {
            task: {
                src: [
                    'Views/Shared/_Layout.cshtml'
                ]
            }
        },
        
        injector: {
            local_dependencies: {
                files: {
                    'Views/Shared/_Layout.cshtml': [
                        'Scripts/**/app.js',
                        'Scripts/**/*.js',
                        '!Scripts/**/_references.js',
                        'Content/**/*.css'
                    ]
                }
            }
        },
        
        ngAnnotate: {
            options: {
                singleQuotes: true,
                remove: true
            },
            app: {
                files: [
                {
                    expand: true,
                    cwd: 'Scripts/',
                    src: ['**/*.js','!_references.js'],
                    dest: 'Scripts/'
                }]
            }
        }
    });

    grunt.registerTask('default', [
        'wiredep',
        'injector',
        'ngAnnotate'
    ]);
}