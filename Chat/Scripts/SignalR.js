(function () {
    var chatHub = $.connection.ChatHub;
    $.connection.hub.start()
        .done(function () {
            console.log("Working!");
            projectHub.server.announce("Connected!");
        })
        .fail(function () { alert("Failed") });

    chatHub.client.updateMessages = function () {
        GetAllMessages()

    };

    function GetAllMessages() {
        var tbl = $('#ChatLog');
        $.ajax({
            url: 'User/ChatWindow?userId=' + $("ReceiverId").val(),
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function(result){
            tbl.append(result);
        }).error(function(){
            alert("Not Done");
        });
    }

})()