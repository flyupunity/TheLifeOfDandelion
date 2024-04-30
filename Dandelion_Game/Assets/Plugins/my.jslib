mergeInto(LibraryManager.library, {

    Hello: function () {
        window.alert("Hello, world!");
        console.log("Hello, world!");
    },
    ShowFullScreenYandexAd: function() {
        //myGameInstance.SendMessage('Manager', 'AdStarted');
        myGameInstance.SendMessage('Progress', 'AdStarted');
        YaGames.init().then(ysdk => {
            //myGameInstance.SendMessage('Manager', 'AdStarted');
            myGameInstance.SendMessage('Progress', 'AdStarted');
            ysdk.adv.showFullscreenAdv({
                callbacks: {
                    onClose: function(wasShown) {
                        // some action after close
                        //myGameInstance.SendMessage('Manager', 'AdEnded');
                        myGameInstance.SendMessage('Progress', 'AdEnded');
                        //myGameInstance.SendMessage('Progress', 'SimulationStandbyModeStatus');
                    },
                    onError: function(error) {
                        // some action on error
                        //myGameInstance.SendMessage('Manager', 'AdEnded');
                        myGameInstance.SendMessage('Progress', 'AdEnded');
                        //myGameInstance.SendMessage('Progress', 'SimulationStandbyModeStatus');
                        console.log(error);
                    }
                }
            })
        });
    },
    //CheckAuthorization: function() {
    //    if(player == null) {
    //        myGameInstance.SendMessage('Progress', 'AuthorizationStatus', false);
    //    } else {
    //        myGameInstance.SendMessage('Progress', 'AuthorizationStatus', true);
    //    }
    //},
    
    StandbyModeStatus: function() {
    //    window.addEventListener('focus', function() {
    //        document.addEventListener('visibilitychange', function () {
    //            if (document.visibilityState == 'hidden') {
    //                myGameInstance.SendMessage('Progress', 'gameHidden');
    //            } else {
    //                myGameInstance.SendMessage('Progress', 'gameShown');
    //            }
    //        });
    //    });
    //    window.addEventListener('blur', function() {
    //        myGameInstance.SendMessage('Progress', 'gameHidden');
    //    });
    },
    SaveExtern: function(date) {
    //    if(player != null) {
    //        var dateString = UTF8ToString(date);
    //        var myobj = JSON.parse(dateString)
    //        player.setData(myobj);
    //    }
    },
    LoadExtern: function () {
    //    if(player != null) {
    //        player.getData().then(_date =>{
    //            const myJSON = JSON.stringify(_date);
    //            myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    //        });
    //    }
    },
    //ShowFullScreenYandexAd: function () {
    //    YaGames.init().then(ysdk => LoadFullScreenYandexAd())
    //},
});