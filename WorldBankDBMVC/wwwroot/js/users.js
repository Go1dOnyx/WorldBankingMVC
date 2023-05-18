function showDepositPopup() {
    var depositPopUp = document.getElementById("popUpDeposit");
    var withCheck = document.getElementById("popUpWithdraw");

    if (depositPopUp.style.display == "block") {
        depositPopUp.style.display = "none";

        if (withCheck.style.display == "block") {
            withCheck.style.display = "none";
        }
    }
    else {
        if (withCheck.style.display == "block") {
            withCheck.style.display = "none";
        }
        depositPopUp.style.display = "block";
    }
}

function showWithdrawPopup() {
    var withdrawPopUp = document.getElementById("popUpWithdraw");
    var checkDeposit = document.getElementById("popUpDeposit");

    if (withdrawPopUp.style.display == "block") {
        withdrawPopUp.style.display = "none";

        if (checkDeposit.style.display == "block") {
            checkDeposit.style.display = "none";
        }
    }
    else {
        if (checkDeposit.style.display == "block") {
            checkDeposit.style.display = "none";
        }
        withdrawPopUp.style.display = "block";
    }
}
function showDepositPopSav() {
    var depositPopUp = document.getElementById("popUpDepSav");
    var withCheck = document.getElementById("popUpWithSav");

    if (depositPopUp.style.display == "block") {
        depositPopUp.style.display = "none";

        if (withCheck.style.display == "block") {
            withCheck.style.display = "none";
        }
    }
    else {
        if (withCheck.style.display == "block") {
            withCheck.style.display = "none";
        }

        depositPopUp.style.display = "block";
    }
}

function showWithdrawPopSav() {
    var withdrawPopUp = document.getElementById("popUpWithSav");
    var depCheck = document.getElementById("popUpDepSav");

    if (withdrawPopUp.style.display == "block") {
        withdrawPopUp.style.display = "none";

        if (depCheck.style.display == "block") {
            depCheck.style.display = "none";
        }
    }
    else {
        if (depCheck.style.display == "block") {
            depCheck.style.display = "none";
        }

        withdrawPopUp.style.display = "block";
    }
}