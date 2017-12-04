/*
调用接口
*/
function call(url, data) {
    var option = {
        url: url,
        type: "POST",
        dataType: "json",
        async: true,
        data: data
    };
    return $.ajax(option);
}
