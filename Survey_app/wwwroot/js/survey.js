
$(document).ready(function () {
    $("body").tooltip({ selector: "[data-bs-toggle=tooltip]" });

    const inputContainer = $(".input-wrap").prop("outerHTML");
    const questionType = $(".question-type").prop("outerHTML");
    const btnHtml =
        '<button type="button" class="remove btn btn-sm btn-danger"' +
        'data-bs-toggle="tooltip" data-bs-placement="right" title="Remove option">' +
        '<i class="bi bi-trash3-fill"></i></button>';

    const addBtn = '<div class="col-md-2">' +
        '<button type = "button" class="add btn btn-sm violet-btn" data - bs - toggle="tooltip" data - bs - placement="right" title = "Add option" >' +
        '<i class="bi bi-plus" > </i></button ></div>';

    $("#addQuestion").click(function (e) {
        e.preventDefault();

        if ($(".input-wrap") > 0) $(inputContainer).insertAfter(".input-wrap:last");
        else $(inputContainer).appendTo("#survey-form");

        const currentIndex = $(".input-wrap").length - 1;

        $(".input-wrap:last > .question-type > .options > .option")
            .attr("name", `Questions[${currentIndex}].Options[${0}].Text`);

        $(".input-wrap:last > .question-container > .question")
            .attr("name", `Questions[${currentIndex}].Text`);

        $(".input-wrap:last").find(".choices")
            .attr("name", `Questions[${currentIndex}].QuestionTypes`);

        $('.tooltip').remove();
    });

    function indexQuestions(options, qIndex) {
        options.each(function (index) {
            $(this).find(".options > .option")
                .attr("name", `Questions[${qIndex}].QuestionsOptions[${index}].Text`);
        });
    }

    $("form").on("click", ".question-type", function (e) {
        e.preventDefault();
        const btn = e.target.closest(".add");
        if (!btn) return;

        const container = $(this).prop("outerHTML");

        $(container).insertAfter($(this).parent().find(".question-type:last"));

        const options = $(this).parent().children(".question-type");
        const qIndex = $(".input-wrap").index($(this).parent(".input-wrap"));

        indexQuestions(options, qIndex);

        $(this).siblings().find(".add").remove();
        $('.tooltip').remove();
    });

    $("form").on("click", ".question-type", function (e) {
        e.preventDefault();
        const remove = e.target.closest(".remove");
        if (!remove) return;

        const current = $(this).parent(".input-wrap")

        if ($(this).siblings(".question-type").length == 0) return;

        if ($(this).parent().find(".question-type:first").is(this)) {
            $(this).next().find(".col-md-2").next().append(addBtn);
        }

        $(this).remove();

        const qIndex = $(".input-wrap").index(current);
        const options = current.children(".question-type")

        indexQuestions(options, qIndex);

        $('.tooltip').remove();
    });

    $("form").on("change", ".input-wrap", function (e) {
        const choice = e.target.closest(".choices");
        if (!choice) return;

        const option = $(choice).val();
        const question = $(this).find(".question-type");

        const qIndex = $(".input-wrap").index(this);
        const options = $(this).children(".question-type")

        switch (option) {
            case "Radio":
                $(question).empty().append($(questionType).html());
                indexQuestions(options, qIndex);
                $(this)
                    .find(".question-type")
                    .find(".add")
                    .not(".add:first")
                    .replaceWith(btnHtml);
                break;
            case "Checkbox":
                $(question).empty().append($(questionType).html());
                $(question).find(":input:first").attr({ type: "checkbox" });
                $(this)
                    .find(".question-type")
                    .find(".add")
                    .not(".add:first")
                    .replaceWith(btnHtml);
                indexQuestions(options, qIndex);
                break;
            case "Text":
                question.not(".question-type:first").remove();
                question.empty().append("<span px-3>Ответ на вопрос</span>");
                break;
        }
    });

    $("form").on("click", ".input-wrap", function (e) {
        e.preventDefault();
        const remove = e.target.closest(".remove-question");
        $('.tooltip').remove();
        if (!remove || $(".input-wrap").length == 1) return;

        $(this).remove();

        $(".input-wrap").each(function (i) {
            $(this).find(".question").attr("name", `Questions[${i}].Text`);
            $(this).find(".choices").attr("name", `Questions[${i}].QuestionTypes`);
            $(this).find(".option").each(function (j) {
                $(this).attr("name", `Questions[${i}].QuestionsOptions[${j}].Text`);
            });
        });
    });

    $("#emailModalbtn").on("click", function (e) {
        e.preventDefault();

        const url = window.location.href;

        if (!url.includes("Edit")) {
            $("#warningModal").modal("show");
            return;
        }

        $("#emailModal").modal("show");
    });
});