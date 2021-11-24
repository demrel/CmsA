////$(document).ready(function () {

 
  
////    $('#nestable').nestable({
////        depth: 0,
      
////    });
   

////    $("#saveList").click(function () {


////        var data = JSON.stringify($('#nestable').nestable('serialize'));
////        console.log(data);
////     var    a = JSON.stringify($('#nestable').nestable('toArray'));
////        console.log(a);
////        //$.ajax({
////        //    url: '/admin/product/updatelist',
////        //    type: "post",
////        //    dataType: 'JSON',
////        //    contentType: 'application/json; charset=utf-8',
////        //    data: data,
////        //    success: function (result) {
////        //        console.log(result);
////        //    }
////        //});
////    });
////});


new Sortable(productOrder, {
    animation: 150,
    ghostClass: 'blue-background-class',
    onEnd: function (evt) {
        var loader = document.getElementById("loading");
        console.log(JSON.stringify(this.toArray()));
       
        console.log("start")
        loader.style.display = "flex";
        $.ajax({
            url: '/admin/product/UpdateOrder',
            type: "post",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(this.toArray()),
        
            success: function (result) {
                console.log("end")
                loader.style.display = "none";
               
            },
            error: function (err) {
                loader.style.display = "none";
            }
           

        });
    }
});

