// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

// use it whene u want to back to index page of pe controle
function GoIndex() {
    var form = document.getElementById("getBackForm");
    form.submit();
}

//var phone = document.getElementById('phone');
//phone.onkeyup = (value) => {
//    ch = value.key;
//    index = 0;
//    if (ch.charCodeAt(index) >= 48 && ch.charCodeAt(index) <= 57 || ch.charCodeAt(index) == 45 || ch.charCodeAt(index) == 43) {
//        if (phone.value.slice(0, -1).includes('-') && ch.charCodeAt(index) == 45) {
//            phone.value = phone.value.slice(0, -1)
//        }
//    }
//    else {
//        if (ch.charCodeAt(index) == 67 || ch.charCodeAt(index) == 83 || ch.charCodeAt(index) == 66 || ch.charCodeAt(index) == 68 || ch.charCodeAt(index) == 65) {
//            console.log('hi')
//        }
//        else {
//            phone.value = phone.value.slice(0, -1);
//            console.log(ch.charCodeAt(index));
//        }
//    }
//}