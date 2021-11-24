﻿(function ($) {
    'use strict';



    /*Tinymce editor*/
    if ($("#tinyMce").length) {
        tinymce.init({
            selector: '#tinyMce',
            height: 500,
            theme: 'silver',
            isTouch: false,
            plugins: [
                'advlist autolink lists link image charmap print preview hr anchor pagebreak',
                'searchreplace wordcount visualblocks visualchars code fullscreen',
                'insertdatetime media nonbreaking save table  directionality',
                'emoticons template paste   textpattern imagetools codesample toc help'
            ],
            toolbar1: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            toolbar2: 'print preview media | forecolor backcolor emoticons | codesample help',
            image_advtab: true,
            templates: [{
                title: 'Test template 1',
                content: 'Test 1'
            },
            {
                title: 'Test template 2',
                content: 'Test 2'
            }
            ],
            content_css: []
        });
    }

  
})(jQuery);