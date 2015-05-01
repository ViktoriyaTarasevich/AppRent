copy: {
        main: {
            files: [
                // includes files within path
                { expand: true, src: ['Photos/*'], dest: 'newPhotos/', filter: 'isFile' },

            ];
        }
}