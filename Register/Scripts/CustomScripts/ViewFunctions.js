function GetDistricts(item) {
    var cityId = item.value; 
    $.ajax({
        url: "districts",
        method: "POST",
        dataType: "json",
        data: { id: cityId },
        success: function (data) {
            $("#district").empty();
         
            var optionhtml1 = '<option value="">' + "Select.." + '</option>';
            $("#district").append(optionhtml1);
          
            $.each(data, function (i) {
                var optionhtml = '<option value="' + data[i].Value + '">' + data[i].Text + '</option>';
                $("#district").append(optionhtml);
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (XMLHttpRequest.responseJSON != undefined) {
                $("#ErrorMessage").html(JSON.parse(XMLHttpRequest.responseText).Message);
            }
            else {
                $('#ErrorMessage').html(errorThrown);
            }
            $("#ErrorModal").modal("show");
        }

    });

}
