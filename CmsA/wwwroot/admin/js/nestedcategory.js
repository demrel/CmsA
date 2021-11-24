$(document).ready(function () {
    $.get("/admin/category/getlist", function (data, status) {
        var dataAjax = data;
        console.log(data);
        var updateOutput = function (e) {
            var list = e.length ? e : $(e.target),
                output = list.data('output');
            if (window.JSON) {
                output.val(window.JSON.stringify(list.nestable('serialize')));//, null, 2));
            }
            else {
                output.val('JSON browser support required for this demo.');
            }
        };

        $('#nestable').nestable({
            json: dataAjax,
            maxDepth: 3,
            group: 1,
            handleClass: "dd-handle card rounded mb-2 border-none",
            //itemClass: "dd-item dd3-item",
            contentClass: "dd-content  media ",
            contentCallback: function (item) {
                var content="";

                if (item.imageName != null) {
                    content += `<img class="img-sm mr-3 mt-1 " src="/images/category/${item.imageName}">`
                }
                content += "<span class='mr-3 mt-3'>" + item.name + "</span>";
                //var id = "/" + item.id;
                //url = "/admin/category/remove" + id;
                //content += '<a href="' + url + '"' + 'class="float-right"><i class="icon-close2  pl-2"></i></a>';
                //var url = "/admin/category/edit" + id;
                //content += '<a href="' + url + '"' + 'class="float-right"><i class="icon-pencil"></i></a>';
                return content;
            }
        }).on('change', updateOutput);
        updateOutput($('#nestable').data('output', $('#nestable-output')));
    });

    $(".editcategory").click(function () {
        console.log("TAdada");
    });

    $("#saveList").click(function () {


        var data = JSON.stringify($('#nestable').nestable('serialize'));
 
        $.ajax({
            url: '/admin/category/updatelist',
            type: "post",
            dataType: 'JSON',
            contentType: 'application/json; charset=utf-8',
            data: data,
            success: function (result) {
                console.log(result);
            }
        });
    });
});