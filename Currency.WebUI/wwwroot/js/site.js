// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ajaxSending() {
    var settings = {
        "url": "http://localhost:7879/api/currency",
        "method": "GET",
        "timeout": 0,
        "headers": {
            "code": document.getElementById("codeId").value.toUpperCase()
        },
    };

    var val = []
    var day = []

    $.ajax(settings).done(function (response) {
        var result = JSON.parse(response);
        console.warn(result)
        if (result.length <1) {
            alert("Code is not exist")
            return
        }
        for (let i = 0; i < result.length; i++) {
            val.push(result[i]["BanknoteBuying"])
            day.push(result[i]["Date"].split("T")[0])
        }
        const ctx = document.getElementById('myChart').getContext('2d');
        const myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: day,
                datasets: [{
                    label: result[0]["Name"] + '/ Banknote Buying',
                    data: val,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    });

}

ajaxSending()

document.getElementById("searchBtn").clic
$("#searchBtn").click(function () {
    ajaxSending()
});