Imports Azure.Identity
Imports Microsoft.Graph
Imports Microsoft.Graph.Models
Imports Microsoft.Graph.Users.Item.SendMail
Imports Microsoft.VisualBasic.Logging

Module Module1
	Dim merrMail As String = "same@vanlommel.be,michielve@vanlommel.be"
	Dim mtoMail As String = "same@vanlommel.be,michielve@vanlommel.be"

	Dim mclientID As String = "xxxxxxxxxxxx"
	Dim mtenantID As String = "xxxxxxxxxxxx"
	Dim mclientSecret As String = "xxxxxxxxxxxx"
	Dim muserID As String = "auto@vanlommel.be"
	Dim mfromMail As String = "no_reply@vanlommel.be"

	Sub Main()
		Dim mRecipients As New List(Of Recipient)
		Dim mFrom As Recipient

		Dim Addresses As String = mtoMail
		Dim mailToAddresses As String() = Addresses.Split(","c)
		For Each address In mailToAddresses
			mRecipients.Add(New Recipient With {
				.EmailAddress = New EmailAddress With {
					.Address = address.Trim()
				}
			})
		Next
		mFrom = New Recipient With {.EmailAddress = New EmailAddress With {.Address = mfromMail}}

		Task.Run(Function() MailNotification(mFrom, mRecipients, "Test .net 4.8", "Dit is een test mail uit een .NET Framework project")).Wait()

		Console.WriteLine("Mail send")
	End Sub


	Async Function MailNotification(from As Recipient, recipient As List(Of Recipient), subject As String, body As String) As Task

		' Azure AD App Credentials
		Dim clientID As String = mclientID
		Dim clientSecret As String = mclientSecret
		Dim tenantID As String = mtenantID
		Dim UserID As String = muserID

		' Microsoft Graph Scope
		Dim scopes As String() = {"https://graph.microsoft.com/.default"}

		Try
			' Authenicate credentials
			Dim options As New TokenCredentialOptions With {
			.AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
			}

			Dim clientSecretCredential As New ClientSecretCredential(tenantID, clientID, clientSecret, options)
			Dim accessToken = Await clientSecretCredential.GetTokenAsync(New Azure.Core.TokenRequestContext(scopes))

			Dim graphClient As New GraphServiceClient(clientSecretCredential, scopes)

			' Create mail message
			Dim requestBody As New SendMailPostRequestBody With {
				.Message = New Message With {
					.Subject = subject,
					.Body = New ItemBody With {
						.ContentType = BodyType.Text,
						.Content = body
					},
					.ToRecipients = recipient,
					.From = from
				},
				.SaveToSentItems = False
			}

			' Send the email
			Await graphClient.Users(UserID).SendMail.PostAsync(requestBody)

		Catch ex As Exception
		End Try

	End Function
End Module
