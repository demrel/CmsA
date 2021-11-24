var OrderCheck = function () {
    const request = new Request('/admin/AdminNotification/checkorder', { method: 'GET' });

    fetch(request)
        .then(response => {
            if (response.status === 200) {
                return response.json();
            } else {
                throw new Error('Something went wrong on api server!');
            }
        })
        .then(response => {
            console.debug(response);
            if (!response)
            {
                document.getElementById("orderDot").style.display = "none";
                document.getElementById("orderDot2").style.display = "none";

            }
        }).catch(error => {
            console.error(error);
        });
};


var UserCheck = function () {
    const request = new Request('/admin/AdminNotification/CheckUser', { method: 'GET' });

    fetch(request)
        .then(response => {
            if (response.status === 200) {
                return response.json();
            } else {
                throw new Error('Something went wrong on api server!');
            }
        })
        .then(response => {
            console.debug(response);
            if (!response) {
                document.getElementById("userDot").style.display = "none";
                document.getElementById("userDot2").style.display = "none";
            }
        }).catch(error => {
            console.error(error);
        });
};


var BonusCheck = function () {
    const request = new Request('/admin/AdminNotification/CheckBonusProduct', { method: 'GET' });

    fetch(request)
        .then(response => {
            if (response.status === 200) {
                return response.json();
            } else {
                throw new Error('Something went wrong on api server!');
            }
        })
        .then(response => {
            console.debug(response);
            if (!response) {
                document.getElementById("bonusDot").style.display = "none";
                document.getElementById("bonusDot2").style.display = "none";
            }
        }).catch(error => {
            console.error(error);
        });
};



var interval = 1000 * 60 * 1; // where X is your every X minutes

setInterval(OrderCheck, interval);
setInterval(BonusCheck, interval);
setInterval(UserCheck, interval);

OrderCheck();
BonusCheck();
UserCheck();