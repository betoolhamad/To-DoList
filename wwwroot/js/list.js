$(document).ready(function(){
    
   $(".fa-plus").click(function(){
       $("input[type='text']").fadeToggle();
   });   
       
    

});

function Search(Description) {
    $.ajax({
        url:'Search',
        type:'POST',
        data : {Description : Description },

        success : function (result) {
            $('#todocontainer').html(result)

        }
    });

}
// function enableEdit(id) {
//     const textElement = document.getElementById(`text-${id}`);
//     textElement.setAttribute("contenteditable", "true");
//     textElement.focus();
// }

// function handleKeyDown(event, id) {
//     if (event.key === "Enter") {
//         event.preventDefault();
//         saveEditedText(id);
//     }
// }

// function saveEditedText(id) {
//     const textElement = document.getElementById(`text-${id}`);
//     const updatedText = textElement.innerText.trim();
//     textElement.setAttribute("contenteditable", "false");

//     $.ajax({
//         url: '/UpdateItem', // مسار دالة UpdateItem في وحدة التحكم
//         type: 'POST',
//         data: { id: id, description: updatedText }, // إرسال id و description
//         success: function (response) {
//             console.log("تم التحديث بنجاح");
//             // يمكنك إضافة تحديث بسيط للواجهة هنا إذا أردت
//         },
//         error: function (error) {
//             console.error("حدث خطأ:", error);
//             alert("حدث خطأ أثناء التحديث."); // عرض رسالة خطأ للمستخدم
//         }
//     });
// }


var get_id;

function showmessage(id) {
    get_id = id;
    $('#del').modal('show');
}
   
function confirmdelete1() {
   
    window.location.href="DeleteItem?id=" + get_id //Pom  لتوجيه المستند توجيه النافذة
   

}


