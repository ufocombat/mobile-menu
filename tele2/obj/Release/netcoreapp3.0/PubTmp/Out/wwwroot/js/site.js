function update() {
    var d = document.getElementById("inp").value;

    $("#result").fadeOut();

    $.ajax({
        url: '/Home/Ren',
        type: "POST",
        cache: false,
        data: JSON.stringify(d),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data) {
                var editor = document.getElementById("result");
                editor.innerHTML = data;
                $("#result").fadeIn();
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

    //$.post("/Home/Ren", { data: d }, function (data, status) {
    //    var editor = document.getElementById("result");
    //    editor.innerHTML = data;
    //    $("#result").fadeIn();
    //});
}

function copy() {
    var editor = document.getElementById("inp");
    editor.select();
    editor.setSelectionRange(0, 99999);
    document.execCommand("copy");
}
