 <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Esource.Views.profile.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="edit-profile">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <div class="col-12 card p-2 rounded-bottom-0 mb-4">
            <h1 class="col-12 text-center">Edit Profile </h1>
        </div>
        <div class="row justify-content-around">
            <!-- Banner -->
            <div class="col-12">

                <div class="card testimonial-card z-depth-2 py-0 mb-5">
                    <h3 class="card-title text-center">Banner</h3>
                    <div class="card testimonial-card z-depth-2 pt-2 jarallax view overlay rounded-bottom">
                        <asp:Image runat="server" ImageUrl="~/Content/img/placeholder.jpg" loading="lazy" id="bannerePic" CssClass="img-fluid jarallax-img  h-100" />
                        <div id="inputBorder" class="mask flex-center waves-effect waves-light rgba-black-strong">
                            <h3 class="text-white">Change Banner</h3>
                        </div>
                        <asp:FileUpload runat="server" CssClass="d-none" name="upload_banner" ID="upload_banner" />
                    </div>
                </div>
            </div>

            <!-- Profile Details -->
            <div class="col-md-12 col-lg-4">
                <!-- Card -->
                <div class="card testimonial-card z-depth-2 pt-2 mb-5">
                    <!-- Avatar -->
                    <div class="avatar mx-auto mt-4 view overlay">
                        <asp:Image loading="lazy" runat="server" ImageUrl="~/Content/img/placeholder.jpg" id="profilePic" CssClass="rounded-circle " />
                        <div id="inputImg" class="mask flex-center waves-effect waves-light rgba-black-strong">
                            <small class="text-white">Change Image</small>
                        </div>
                        <asp:FileUpload runat="server" CssClass="d-none" name="upload_image" ID="upload_image" />
                    </div>
                    <!-- Content -->
                    <div class="card-body">
                        <!-- Name -->
                        <h3 runat="server" id="currUsername" class="card-title"></h3>

                        <h5 runat="server" id="usertype" class="card-title text-muted">Service Provider
                        </h5>


                        <div class="md-form md-outline">
                            <input runat="server" type="url" class="form-control" name="website" id="website" aria-describedby="helpId"
                                placeholder="e.g. www.mywebsite.com" value="">
                            <label for="website" class="text-left">Website</label>
                        </div>


                        <div class="md-form md-outline">
                            <input runat="server" placeholder="e.g. 1/1/2020" type="text" id="dob" name="dob"
                                class="form-control" value="">
                            <label for="dob" class="text-left">Birthday</label>
                        </div>


                        <div class="select-outline text-left">
                            <label for="gender" class="text-left">Gender</label>
                            <select runat="server" name="gender" id="gender"
                                class="md-form md-outline custom-select m-0">
                                <option value="Not Set" selected>Not Set</option>
                                <option value="Male">Male</option>
                                <option value="Female">Female</option>
                            </select>
                        </div>

                        <div class="select-outline text-left mb-4 mt-2">
                            <label for="location" class="text-left">Country</label>
                            <select runat="server" name="location" id="location"
                                class="md-form md-outline custom-select m-0"
                                placeholder="Country">
                                <option value="Not Set">Not Set</option>
                            </select>
                        </div>

                        <div class="md-form md-outline mt-4">
                            <input type="text" runat="server" class="form-control" name="occupation" id="occupation"
                                aria-describedby="helpId" placeholder="e.g. Illustrator" value="">
                            <label for="occupation" class="text-left">Occupation</label>
                        </div>

                        <hr class="hr-primary">
                        <div class="mt-5 text-center py-4">
                            <h4 class="card-title">Delete Account</h4>
                            <a class="btn btn-danger btn-md" data-toggle="modal" data-target="#confirm{{id}}"><i
                                class="fas fa-trash-alt fa-lg mr-1"></i>Delete Account</a>
                        </div>
                        <hr class="hr-primary">
                        <div class="mt-5 text-center py-4">
                            <h4 class="card-title">Change Password</h4>
                            <a class="btn btn-secondary btn-md" href="<%=Page.ResolveUrl("~/Views/auth/changepass.aspx") %>"><i
                                class="fas fa-key fa-lg mr-1"></i>Change Password</a>
                        </div>
                    </div>
                </div>


            </div>
            <!-- Social Medias -->
            <div class="col-md-12 col-lg-4">
                <!-- Card -->
                <div class="card testimonial-card z-depth-2 pt-2 mb-5">
                    <div class="card-body">
                        <!-- Name -->
                        <h3 class="card-title">Social Medias</h3>

                        <div class="md-form md-outline">
                            <input type="url" runat="server" class="form-control" name="twitter" id="twitter" aria-describedby="helpId"
                                placeholder="e.g. https:///www.twitter.com/username" value="">
                            <label for="twitter" class="text-left">Twitter </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" runat="server" class="form-control" name="instagram" id="instagram" aria-describedby="helpId"
                                placeholder="e.g. https:///www.instagram.com/username" value="">
                            <label for="instagram" class="text-left">Instagram </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" runat="server" class="form-control" name="facebook" id="facebook" aria-describedby="helpId"
                                placeholder="e.g. https:///www.facebook.com/username" value="">
                            <label for="facebook" class="text-left">Facebook </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" runat="server" class="form-control" name="youtube" id="youtube" aria-describedby="helpId"
                                placeholder="e.g. https:///www.youtube.com/channel/username"
                                value="">
                            <label for="youtube" class="text-left">YouTube </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" runat="server" class="form-control" name="deviantart" id="deviantart"
                                aria-describedby="helpId" placeholder="e.g. https://www.deviantart.com/username"
                                value="">
                            <label for="deviantart" class="text-left">Deviantart </label>
                        </div>
                    </div>
                </div>
                <div class="card z-depth-2 pt-2">
                    <div class="card-body">
                        <h5 class="text-center">Set a custom PIN number for your job/request (Optional)</h5>
                        <a runat="server" id="removepinmodallaucher" class="btn btn-danger text-right" data-tooltip="tooltip" data-placement="top" title="Delete" data-backdrop="false" data-toggle="modal" data-target="#removepinmodal">
                            <i class="fas fa-unlock-alt"></i>
                            Remove PIN
                        </a>
                        <a class="btn btn-success text-right" data-tooltip="tooltip" data-placement="top" title="Delete" data-backdrop="false" data-toggle="modal" data-target="#changepinmodal">
                            <i class="fas fa-lock"></i>
                            <span runat="server" id="setPinModalLauncher">Set PIN</span>
                        </a>
                    </div>
                </div>

            </div>
            <!-- Miscellaneous -->
            <div class="col-md-12 col-lg-4">
                <div class="z-depth-2 card">
                    <!-- Content -->
                    <div class="card-body">
                        <!-- Name -->
                        <h4 class="card-title text-left">Bio</h4>
                        <div class="md-form md-outline">
                            <textarea runat="server" class="form-control rounded-0" id="bio" name="bio" value="" rows="7"
                                placeholder="Tell us about youself.."></textarea>
                            <label for="bio">Bio</label>
                        </div>
                        <hr class="hr-primary">

                        <h4 class="card-title text-left">Skills</h4>
                        <div id="skillInputList" class="">

                            <div style="" id="skillInput1" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill1" id="skill1"
                                    placeholder="e.g. Illustrator" value="" runat="server">
                                <label for="skill1Label" class="text-left">Skill 1 </label>
                            </div>

                            <div style="" id="skillInput2" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill2" id="skill2"
                                    placeholder="e.g. Illustrator" value="" runat="server">
                                <label for="skill2Label" class="text-left">Skill 2 </label>
                            </div>

                            <div style="" id="skillInput3" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill3" id="skill3"
                                    placeholder="e.g. Illustrator" value="" runat="server">
                                <label for="skill3Label" class="text-left">Skill 3 </label>
                            </div>

                            <div style="" id="skillInput4" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill4" id="skill4"
                                    placeholder="e.g. Illustrator" value="" runat="server">
                                <label for="skill4Label" class="text-left">Skill 4 </label>
                            </div>

                            <div style="" id="skillInput5" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill5" id="skill5"
                                    placeholder="e.g. Illustrator" value="" runat="server">
                                <label for="skill5Label" class="text-left">Skill 5 </label>
                            </div>

                        </div>
                        <div class="mx-auto row justify-content-between">
                            <asp:LinkButton type="button" class="btn btn-md btn-secondary" id="addButton">Add Skill</asp:LinkButton>
                            <asp:LinkButton type="button" class="btn btn-md btn-secondary" id="removeButton">Remove Skill</asp:LinkButton>
                        </div>

                        <hr class="hr-primary">

                        <div class="mx-auto row justify-content-between">
                            <a href="<%=Page.ResolveUrl("~/Views/profile/index.aspx") %>" class="btn btn-md btn-secondary">Back
                            </a>

                            <asp:Button ID="updateProfile" runat="server" CssClass="btn btn-md btn-secondary" Text="Update Changes" OnClick="updateProfile_Click" />
<%--                            <button type="submit" class="btn btn-md btn-secondary">Update Changes</button>--%>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="confirm{{id}}" tabindex="-1" role="dialog" aria-labelledby="label"
                    aria-hidden="true">

                    <!-- Change class .modal-sm to change the size of the modal -->
                    <div class="modal-dialog modal-sm" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title w-100" id="label">Confirm Delete?</h4>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="my-2 row justify-content-around mx-auto col-12">
                                <a type="button" class="btn btn-danger" href="./edit/{{user.id}}">Yes
                                </a>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="changepinmodal" tabindex="-1" role="dialog" data-backdrop="false"
                    aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Please enter password and desired PIN number to set PIN</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body text-center">
                                        <div class="md-form md-outline">
                                            <input type="password" maxlength="6" runat="server" class="form-control w-50" id="jobpin" />
                                            <label for="jobpin" class="text-left">Job PIN</label>
                                        </div>
                                        <div class="md-form md-outline">
                                            <input runat="server" id="tbcfmpin" type="password" class="form-control" />
                                            <label for="tbcfmpin">Password</label>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">Cancel</button>
                                        <asp:LinkButton runat="server" ID="btn_PIN" CssClass="btn btn-sm btn-success text-right" OnClick="btn_PIN_Click">
                            Confirm
                                        </asp:LinkButton>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal fade" id="removepinmodal" tabindex="-1" role="dialog" data-backdrop="false"
                    aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Please enter password to remove your PIN</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body text-center">
                                        <div class="md-form md-outline">
                                            <input runat="server" id="tbremove" type="password" class="form-control" />
                                            <label for="tbremove">Password</label>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">Cancel</button>
                                        <asp:LinkButton runat="server" ID="btnremove" CssClass="btn btn-sm btn-success text-right" OnClick="btnremove_Click">
                            Confirm
                                        </asp:LinkButton>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/profile.js") %>"></script>
</asp:Content>
