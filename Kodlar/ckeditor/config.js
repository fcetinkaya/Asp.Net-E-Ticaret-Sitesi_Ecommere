/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
    config.language = 'tr';
    config.uiColor = '#e7e7e7';
    config.autoParagraph = false;
    config.entities = false;
    config.allowedContent = true;
    config.protectedSource.push(/<i[^>]*><\/i>/g);
};
