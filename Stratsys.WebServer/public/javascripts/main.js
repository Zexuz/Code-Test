window.onload = function () {
    initEventListeners();

    document.getElementById("height").value = 150;
    document.getElementById("age").value = 30;
};


function initEventListeners() {
    document.getElementById("calculate-recomended").addEventListener("click", getRecomendedSkiLength);
}


function getRecomendedSkiLength() {
    const url = "http://localhost:5000/api/v1/ski/recomended";

    const height = document.getElementById("height").value;
    const age = document.getElementById("age").value;
    const skitype = $("input[name=group1]:checked").val();

    const model = {
        height: height,
        age: age,
        skiType: skitype
    };

    $.postJSON(
        url,
        model,
        function (data, status) {
            showRecomendedRange({model: model, result: data});
        },
        function (error) {
            M.toast({html: 'Statuscode: '+error.status + ". Error: " + error.responseText});
        });
}

function showRecomendedRange(data) {
    let queryString = "?age="+data.model.age+"&height="+data.model.height+"&skitype="+data.model.skiType+"&min="+data.result.min+"&max="+data.result.max;
    document.location = "http://localhost:3000/result"+queryString;
}


$.postJSON = function (url, data, callback, error) {
    return jQuery.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'type': 'POST',
        'url': url,
        'data': JSON.stringify(data),
        'dataType': 'json',
        'success': callback,
        'error':error
    });
};
