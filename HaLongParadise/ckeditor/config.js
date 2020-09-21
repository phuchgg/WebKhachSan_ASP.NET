/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	 config.language = 'vi';
    // config.uiColor = '#AADC6E';
	 config.entities = false;

	 //var path = 'http://localhost:51260'; // code
    var path = 'http://' + window.location.hostname;// Website

	 config.filebrowserBrowseUrl =  path+'/ckeditor/ckfinder/ckfinder.html';

	 config.filebrowserImageBrowseUrl = path + '/ckeditor/ckfinder/ckfinder.html?type=Images';

	 config.filebrowserFlashBrowseUrl = path + '/ckeditor/ckfinder/ckfinder.html?type=Flash';

	 config.filebrowserUploadUrl = path + '/ckeditor/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files';

	 config.filebrowserImageUploadUrl = path + '/ckeditor/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images';

	 config.filebrowserFlashUploadUrl = path + '/ckeditor/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Flash';

};
