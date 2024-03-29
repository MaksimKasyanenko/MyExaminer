﻿window.addEventListener("load", async function () {
    let display = new TestingDisplay(
        document.getElementById("questionNum"),
        document.getElementById("questionText"),
        document.getElementById("questionSubText"),
        document.getElementById("questionCast")
    );
    let formManager = new FormManager();
    formManager.register("confirm", new ConfirmForm());
    let textAnswerForm = new TextAnswerForm();
    formManager.register("TextAnswer", textAnswerForm);
    formManager.register("OneOfFourVariantsAnswer", new OneOfFourVariantsAnswerForm());
    formManager.register("SomeVariantsAnswer", new SomeVariantsAnswerForm());
    formManager.register("SequenceAnswer", new SequenceAnswerForm());
    formManager.register("ConnectedPairsAnswer", new ConnectedPairsAnswerForm());
    formManager.hideForms();
    let confirmForm = formManager.getForm("confirm");
    let timer = new TestingTimer(document.getElementById("timerDisp"));
    let sessionId = document.getElementById("scriptData").dataset.sessionid;
    let server = new Server("/api/Testing", Number.parseInt(sessionId));
    await server.updateState();
    timer.time = server.testState.timeLeft;
    timer.start();
    while (!server.testState.finished) {
        display.update(server.testState.questionNum, server.testState.questionText, server.testState.questionSubText,server.testState.questionCost);
        let aForm = formManager.getForm(server.testState.answerType);
        aForm.fill(server.testState.addition);
        let answer = await aForm.showAndGetAnswer();
        aForm.hide();
        let answerResult = await server.answer(answer);
        if (answerResult.isRight) {
            display.showMessage("Правильно!","");
        } else {
            display.showMessage("Неправильно!", `Правильна відповідь:\n${answerResult.rightText}`);
        }
        await confirmForm.showAndGetAnswer();
        confirmForm.hide();
        display.clear();
        await server.updateState();
        timer.time = server.testState.timeLeft;
    }
    window.location.href = `${document.getElementById("scriptData").dataset.hrefresult}/${server.testState.resultId}`;
});
