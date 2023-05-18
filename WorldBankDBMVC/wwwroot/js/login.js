function showPass() {
    var x = document.getElementById("passID");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
