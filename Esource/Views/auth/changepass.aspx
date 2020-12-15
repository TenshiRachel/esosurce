<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="Esource.Views.auth.changepass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="change-password">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card p-4">
                    <h3 class="text-center">Change Password</h3>
                    <div class="md-form md-outline">
                        <input id="currPass" type="password" class="form-control" name="currpass" runat="server" required>
                        <label for="currPass">Current Password</label>
                    </div>

                    <div class="md-form md-outline">
                        <input id="newPass" type="password" class="form-control" name="newpass" runat="server" required>
                        <label for="newPass">New Password</label>
                    </div>

                    <div class="md-form md-outline">
                        <input id="confPass" type="password" class="form-control" name="confirmpass" runat="server" required>
                        <label for="confPass">Confirm New Password</label>
                    </div>

                    <asp:LinkButton runat="server" ID="btnChangePassword" CssClass="btn btn-md btn-outline-primary btn-block" OnClick="btnChangePassword_Click">
                        <i class="fas fa-edit mr-2"></i>Change Password
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
