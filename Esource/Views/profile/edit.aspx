<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Esource.Views.profile.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="edit-profile">
        <div class="col-12 card p-2 rounded-bottom-0 mb-4">
            <h1 class="col-12 text-center">Edit Profile </h1>
        </div>
        <div class="row justify-content-around">
            <!-- Banner -->
            <div class="col-12">

                <div class="card testimonial-card z-depth-2 py-0 mb-5">
                    <h3 class="card-title text-center">Banner</h3>
                    <div class="card testimonial-card z-depth-2 pt-2 jarallax view overlay rounded-bottom">
                        <img loading="lazy" id="bannerePic" class="img-fluid jarallax-img  h-100"
                            onerror='this.src="/img/profile/banner.png"' src="/uploads/profile/{{user.id}}/banner.png"
                            alt="">
                        <div id="inputBorder" class="mask flex-center waves-effect waves-light rgba-black-strong">
                            <h3 class="text-white">Change Banner</h3>
                        </div>
                        <input type="file" class="d-none" name="upload_banner" id="upload_banner">
                        <input type="hidden" name="bannerString" id="bannerString">
                    </div>
                </div>
            </div>

            <!-- Profile Details -->
            <div class="col-md-12 col-lg-4">
                <!-- Card -->
                <div class="card testimonial-card z-depth-2 pt-2 mb-5">
                    <!-- Avatar -->
                    <div class="avatar mx-auto white mt-4 view overlay">
                        <img loading="lazy" onerror='this.src = "/img/profile/default.png"'
                            src="/uploads/profile/{{user.id}}/profilePic.png" id="profilePic" class="rounded-circle "
                            alt="">
                        <div id="inputImg" class="mask flex-center waves-effect waves-light rgba-black-strong">
                            <small class="text-white">Change Image</small>
                        </div>
                        <input type="file" class="d-none" name="upload_image" id="upload_image">
                        <input type="hidden" name="imgString" id="imgString">
                    </div>
                    <!-- Content -->
                    <div class="card-body">
                        <!-- Name -->
                        <h3 class="card-title">User</h3>

                        <h5 class="card-title text-muted">Service Provider
                        </h5>


                        <div class="md-form md-outline">
                            <asp:Label CssClass="text-left" runat="server" Text="Website" AssociatedControlID="TbWebsite"></asp:Label>
                            <asp:TextBox ID="TbWebsite" CssClass="form-control" runat="server"></asp:TextBox>

<%--                            <input type="url" class="form-control" name="website" id="website" aria-describedby="helpId"
                                placeholder="e.g. www.mywebsite.com" value="">
                            <label for="website" class="text-left">Website</label>--%>
                        </div>


                        <div class="md-form md-outline">
                            <input placeholder="Selected date" type="text" id="dob" name="dob"
                                class="form-control datepicker" value="">
                            <label for="dob" class="text-left">Birthday</label>

                        </div>


                        <div class="select-outline text-left">
                            <label for="gender" class="text-left">Gender</label>
                            <select name="gender" id="gender"
                                class="mdb-select md-form md-outline colorful-select dropdown-primary">
                                <option value="Not Set" selected>Not Set</option>
                                <option value="Male">Male</option>
                                <option value="Female">Female</option>
                                <option value="Others">Others</option>

                            </select>
                        </div>

                        <div class="select-outline text-left mb-n4">
                            <label for="location" class="text-left">Country</label>
                            <select name="location" id="location"
                                class="mdb-select md-form md-outline colorful-select dropdown-primary"
                                placeholder="Country">
                                <option value="Not Set">Not Set</option>
                                <option value="{{this.name}}">{{this.name}}</option>
                            </select>
                        </div>

                        <div class="md-form md-outline">
                            <input type="text" class="form-control" name="occupation" id="occupation"
                                aria-describedby="helpId" placeholder="e.g. Illustrator" value="">
                            <label for="occupation" class="text-left">Occupation</label>
                        </div>

                        <hr class="hr-primary">
                        <div class="mt-5 text-center py-4">
                            <h4 class="card-title">Delete Account</h4>
                            <a class="btn btn-danger btn-md" data-toggle="modal" data-target="#confirm{{id}}"><i
                                class="fas fa-trash-alt fa-lg"></i>Delete Account</a>
                        </div>
                        <hr class="hr-primary">
                        <div class="mt-5 text-center py-4">
                            <h4 class="card-title">Change Password</h4>
                            <a class="btn btn-secondary btn-md" href="/changepass"><i
                                class="fas fa-key fa-lg"></i>Change Password</a>
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
                            <input type="url" class="form-control" name="twitter" id="twitter" aria-describedby="helpId"
                                placeholder="e.g. https:///www.twitter.com/{{user.username}}123" value="">
                            <label for="twitter" class="text-left">Twitter </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" class="form-control" name="instagram" id="instagram" aria-describedby="helpId"
                                placeholder="e.g. https:///www.instagram.com/{{user.username}}123"
                                value="">
                            <label for="instagram" class="text-left">Instagram </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" class="form-control" name="facebook" id="facebook" aria-describedby="helpId"
                                placeholder="e.g. https:///www.facebook.com/{{user.username}}123" value="">
                            <label for="facebook" class="text-left">Facebook </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" class="form-control" name="youtube" id="youtube" aria-describedby="helpId"
                                placeholder="e.g. https:///www.youtube.com/channel/UCFKDEp9si4RmHFWJW1vYsMA"
                                value="">
                            <label for="youtube" class="text-left">YouTube </label>
                        </div>

                        <div class="md-form md-outline">
                            <input type="url" class="form-control" name="deviantart" id="deviantart"
                                aria-describedby="helpId" placeholder="e.g. https://www.deviantart.com/{{user.username}}123"
                                value="">
                            <label for="deviantart" class="text-left">Deviantart </label>
                        </div>
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
                            <textarea class="form-control rounded-0" id="bio" name="bio" value="" rows="7"
                                placeholder="Tell us about youself..">Not Set</textarea>
                            <label for="bio">Bio</label>
                        </div>
                        <hr class="hr-primary">

                        <h4 class="card-title text-left">Skills</h4>
                        <div id="skillInputList" class="">

                            <div style="" id="skillInput1" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill1" id="skill1"
                                    placeholder="e.g. Illustrator" value="">
                                <label for="skill1Label" class="text-left">Skill 1 </label>
                            </div>

                            <div style="" id="skillInput2" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill2" id="skill2"
                                    placeholder="e.g. Illustrator" value="">
                                <label for="skill2Label" class="text-left">Skill 2 </label>
                            </div>

                            <div style="" id="skillInput3" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill3" id="skill3"
                                    placeholder="e.g. Illustrator" value="">
                                <label for="skill3Label" class="text-left">Skill 3 </label>
                            </div>

                            <div style="" id="skillInput4" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill4" id="skill4"
                                    placeholder="e.g. Illustrator" value="">
                                <label for="skill4Label" class="text-left">Skill 4 </label>
                            </div>

                            <div style="" id="skillInput5" class="md-form md-outline">
                                <input type="text" class="form-control" name="skill5" id="skill5"
                                    placeholder="e.g. Illustrator" value="">
                                <label for="skill5Label" class="text-left">Skill 5 </label>
                            </div>

                        </div>
                        <div class="mx-auto row justify-content-between">
                            <button type="button" class="btn btn-md btn-secondary" id="addButton">Add Skill</button>
                            <button type="button" class="btn btn-md btn-secondary" id="removeButton">Remove Skill</button>
                        </div>

                        <hr class="hr-primary">

                        <div class="mx-auto row justify-content-between">
                            <a href="/profile/" onclick="e.preventDefault();" class="btn btn-md btn-secondary">Back
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
            </div>
        </div>
        <div class="modal fade" id="confirm{{id}}" tabindex="-1" role="dialog" aria-labelledby="label" aria-hidden="true">

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
    </section>
</asp:Content>
