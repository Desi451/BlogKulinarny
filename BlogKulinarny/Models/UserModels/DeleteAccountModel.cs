﻿namespace BlogKulinarny.Models.UserModels;

public class DeleteAccountModel
{
    public string Password { get; set; }
    public bool ConfirmDeletion { get; set; }
}